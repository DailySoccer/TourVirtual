//
//  MDPGroupModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPGroupModel.h"


#pragma mark Sport Type
typedef NS_ENUM(NSInteger, MDPGroupModelGroupType) {
    MDPGroupModelGroupTypePrivate           = 1,
    MDPGroupModelGroupTypeCommunity         = 2,
    MDPGroupModelGroupTypeReserved          = 3,
} ;


#pragma mark - Interface
@interface MDPGroupModel : _MDPGroupModel

+ (MDPGroupModel *)groupWithIdGroup:(NSString *)idGroup
                           language:(NSString *)language
                              fanMe:(BOOL)fanMe
               managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)groupWithIdSeason:(NSString *)idSeason
                    idCompetition:(NSString *)idCompetition
                          idMatch:(NSString *)idMatch
                         language:(NSString *)language
             managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsGroupWithFanMe:(BOOL)fanMe
                                       language:(NSString *)language
                                     dictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsGroupWithIdSeason:(NSString *)idSeason
                                     idCompetition:(NSString *)idCompetition
                                           idMatch:(NSString *)idMatch
                                          language:(NSString *)language
                                        dictionary:(NSDictionary *)dictionary
                              managedObjectContext:(NSManagedObjectContext *)context;

@end
