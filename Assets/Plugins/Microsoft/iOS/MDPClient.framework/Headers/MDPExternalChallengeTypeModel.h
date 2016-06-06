//
//  MDPExternalChallengeTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPExternalChallengeTypeModel.h"


#pragma mark - Interface
@interface MDPExternalChallengeTypeModel : _MDPExternalChallengeTypeModel

+ (MDPExternalChallengeTypeModel *)externalChallengeTypeWithIdExternalChallenge:(NSString *)idExternalChallenge managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)externalChallengeTypeWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsExternalChallengeTypeWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
