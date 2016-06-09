//
//  _MDPCommentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCommentModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCommentModelAttributes {
	__unsafe_unretained NSString *bannedText;
	__unsafe_unretained NSString *idMessage;
	__unsafe_unretained NSString *idSender;
	__unsafe_unretained NSString *idThread;
	__unsafe_unretained NSString *isBanned;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *text;
	__unsafe_unretained NSString *timeStampSent;
} MDPCommentModelAttributes;

extern const struct MDPCommentModelRelationships {
	__unsafe_unretained NSString *answers;
	__unsafe_unretained NSString *pagedCommentsResults;
} MDPCommentModelRelationships;

@class MDPCommentAnswerModel;
@class MDPPagedCommentsModel;

@interface _MDPCommentModel : NSManagedObject

@property (nonatomic, strong) NSString* bannedText;

//- (BOOL)validateBannedText:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSString* timeStampSent;

//- (BOOL)validateTimeStampSent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *answers;

- (NSMutableSet*)answersSet;

@property (nonatomic, strong) MDPPagedCommentsModel *pagedCommentsResults;

//- (BOOL)validatePagedCommentsResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCommentModel (AnswersCoreDataGeneratedAccessors)
- (void)addAnswers:(NSSet*)value_;
- (void)removeAnswers:(NSSet*)value_;
- (void)addAnswersObject:(MDPCommentAnswerModel*)value_;
- (void)removeAnswersObject:(MDPCommentAnswerModel*)value_;
@end

@interface _MDPCommentModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveBannedText;
- (void)setPrimitiveBannedText:(NSString*)value;

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

- (NSString*)primitiveTimeStampSent;
- (void)setPrimitiveTimeStampSent:(NSString*)value;

- (NSMutableSet*)primitiveAnswers;
- (void)setPrimitiveAnswers:(NSMutableSet*)value;

- (MDPPagedCommentsModel*)primitivePagedCommentsResults;
- (void)setPrimitivePagedCommentsResults:(MDPPagedCommentsModel*)value;

@end
