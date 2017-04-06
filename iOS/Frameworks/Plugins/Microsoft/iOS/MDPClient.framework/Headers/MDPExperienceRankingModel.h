//
//  MDPExperienceRankingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPExperienceRankingModel.h"


#pragma mark - Interface
@interface MDPExperienceRankingModel : _MDPExperienceRankingModel

+ (NSArray *)experienceRankingWithIdClient:(NSString *)idClient
                      managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)experienceRankingWithIdClient:(NSString *)idClient
                                       idUser:(NSString *)idUser
                         managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary
                            idClient:(NSString *)idClient
                managedObjectContext:(NSManagedObjectContext *)context;

@end
