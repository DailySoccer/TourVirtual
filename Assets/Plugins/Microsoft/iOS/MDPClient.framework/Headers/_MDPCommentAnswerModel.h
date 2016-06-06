//
//  _MDPCommentAnswerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCommentAnswerModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCommentAnswerModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *avatarName;
	__unsafe_unretained NSString *avatarThumbnailName;
	__unsafe_unretained NSString *bannedText;
	__unsafe_unretained NSString *idAnswer;
	__unsafe_unretained NSString *idMessage;
	__unsafe_unretained NSString *idSender;
	__unsafe_unretained NSString *idThread;
	__unsafe_unretained NSString *isBanned;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *text;
	__unsafe_unretained NSString *timeStampSent;
} MDPCommentAnswerModelAttributes;

extern const struct MDPCommentAnswerModelRelationships {
	__unsafe_unretained NSString *commentCommentAnswer;
	__unsafe_unretained NSString *pagedAnswersResults;
} MDPCommentAnswerModelRelationships;

@class MDPCommentModel;
@class MDPPagedAnswersModel;

@interface _MDPCommentAnswerModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarName;

//- (BOOL)validateAvatarName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarThumbnailName;

//- (BOOL)validateAvatarThumbnailName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* bannedText;

//- (BOOL)validateBannedText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAnswer;

//- (BOOL)validateIdAnswer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMessage;

//- (BOOL)validateIdMessage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSender;

//- (BOOL)validateIdSender:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idThread;

//- (BOOL)validateIdThread:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isBanned;

@property (atomic) BOOL isBannedValue;
- (BOOL)isBannedValue;
- (void)setIsBannedValue:(BOOL)value_;

//- (BOOL)validateIsBanned:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* text;

//- (BOOL)validateText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* timeStampSent;

//- (BOOL)validateTimeStampSent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPCommentModel *commentCommentAnswer;

//- (BOOL)validateCommentCommentAnswer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedAnswersModel *pagedAnswersResults;

//- (BOOL)validatePagedAnswersResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCommentAnswerModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveAvatarName;
- (void)setPrimitiveAvatarName:(NSString*)value;

- (NSString*)primitiveAvatarThumbnailName;
- (void)setPrimitiveAvatarThumbnailName:(NSString*)value;

- (NSString*)primitiveBannedText;
- (void)setPrimitiveBannedText:(NSString*)value;

- (NSString*)primitiveIdAnswer;
- (void)setPrimitiveIdAnswer:(NSString*)value;

- (NSString*)primitiveIdMessage;
- (void)setPrimitiveIdMessage:(NSString*)value;

- (NSString*)primitiveIdSender;
- (void)setPrimitiveIdSender:(NSString*)value;

- (NSString*)primitiveIdThread;
- (void)setPrimitiveIdThread:(NSString*)value;

- (NSNumber*)primitiveIsBanned;
- (void)setPrimitiveIsBanned:(NSNumber*)value;

- (BOOL)primitiveIsBannedValue;
- (void)setPrimitiveIsBannedValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveText;
- (void)setPrimitiveText:(NSString*)value;

- (NSDate*)primitiveTimeStampSent;
- (void)setPrimitiveTimeStampSent:(NSDate*)value;

- (MDPCommentModel*)primitiveCommentCommentAnswer;
- (void)setPrimitiveCommentCommentAnswer:(MDPCommentModel*)value;

- (MDPPagedAnswersModel*)primitivePagedAnswersResults;
- (void)setPrimitivePagedAnswersResults:(MDPPagedAnswersModel*)value;

@end
