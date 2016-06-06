//
//  MDPExternalChallengeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPExternalChallengeModel.h"


#pragma mark - Interface
@interface MDPExternalChallengeModel : _MDPExternalChallengeModel

+ (MDPExternalChallengeModel *)externalChallengeWithIdExternalChallenge:(NSString *)idExternalChallenge managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)externalChallengesWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsExternalChallengeWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
