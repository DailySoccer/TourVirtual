//
//  MDPStandingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPStandingModel.h"


#pragma mark QualificationType
typedef NS_ENUM(NSInteger, MDPStandingModelQualificationType) {
    MDPStandingModelQualificationTypeUnknown                         = 0,
    MDPStandingModelQualificationTypePromotion                       = 1,
    MDPStandingModelQualificationTypeRelegation                      = 2,
    MDPStandingModelQualificationTypePlayoff_Relegation              = 3,
    MDPStandingModelQualificationTypeEuropa_Cup                      = 4,
    MDPStandingModelQualificationTypeChampions_League_Qualifying     = 5,
    MDPStandingModelQualificationTypeChampions_league                = 6,
};


#pragma mark - Interface
@interface MDPStandingModel : _MDPStandingModel

+ (NSArray *)standingItemsWithIdSeason:(NSString *)idSeason idCompetition:(NSString *)idCompetition matchDay:(NSString *)matchDay idGroup:(NSString *)idGroup managedObjectContext:(NSManagedObjectContext *)context;


+ (instancetype)insertIfNotExistsStandingWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)standingItemsWithIdSeason:(NSString *)idSeason
                         idCompetition:(NSString *)idCompetition
                              matchDay:(NSString *)matchDay
                  managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)standingItemsFetchedResultsControllerWithIdSeason:(NSString *)idSeason
                                                                    idCompetition:(NSString *)idCompetition
                                                                         matchDay:(NSString *)matchDay
                                                                          idGroup:(NSString *)idGroup
                                                             managedObjectContext:(NSManagedObjectContext *)context
                                                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
