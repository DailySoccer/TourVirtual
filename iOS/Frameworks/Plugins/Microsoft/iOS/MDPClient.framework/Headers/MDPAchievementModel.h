//
//  MDPAchievementModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAchievementModel.h"


#pragma mark - Interface
@interface MDPAchievementModel : _MDPAchievementModel

+ (instancetype)insertIfNotExistsAchievementWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)achievementFetchedResultsControllerWithIdUser:(NSString *)idUser
                                                                         type:(NSString *)type
                                                       managedObjectContext:(NSManagedObjectContext *)context
                                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (instancetype)achievementWithIdUser:(NSString *)idUser idAchievement:(NSString *)idAchievement level:(uint)level managedObjectContext:(NSManagedObjectContext *)context;

@end
